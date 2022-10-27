using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance.Services
{
    public class AppUserService : BaseService<AppUser>, IAppUserService
    {
        private readonly IReadAppUserRepository _readAppUserRepository;
        private readonly IWriteAppUserRepository _writeAppUserRepository;
        private readonly IReadRoleRepository _readRoleRepository;
        private readonly IReadAppUserRoleRepository _readAppUserRoleRepository;
        private readonly IWriteAppUserRoleRepository _writeAppUserRoleRepository;
        private readonly ITokenHelper _tokenHelper;

        public AppUserService(IReadAppUserRepository readAppUserRepository, IWriteRepository<AppUser> writeRepository, IWriteAppUserRoleRepository writeAppUserRoleRepository, IWriteAppUserRepository writeAppUserRepository, IReadRoleRepository readRoleRepository, IReadAppUserRoleRepository readAppUserRoleRepository, ITokenHelper tokenHelper) : base(readAppUserRepository, writeRepository)
        {
            _readAppUserRepository = readAppUserRepository;
            _writeAppUserRoleRepository = writeAppUserRoleRepository;
            _writeAppUserRepository = writeAppUserRepository;
            _readRoleRepository = readRoleRepository;
            _readAppUserRoleRepository = readAppUserRoleRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessTokenAsync(AppUser entity)
        {
            AppUser user = await _readAppUserRepository.GetByEmailAsync(entity.Email);

            List<AppUserRole> appUserRoles = await _readAppUserRoleRepository.GetAppUserID(entity.ID);

            List<Role> roles = await _readRoleRepository.GetActive().ToListAsync();

            if (appUserRoles.Count == 0)//Her token yaratma işleminde AppUserRole eklemek için kontrol yapıyoruz.
            {
                if (user.Email != "gvn.boydak@gmail.com")//Member Rol Atama
                {
                    AppUserRole appUserRole = new AppUserRole()
                    {
                        AppUserID = user.ID,
                        RoleID = roles.FirstOrDefault(x => x.Name.Contains("Member")).ID
                    };
                   await _writeAppUserRoleRepository.AddAsync(appUserRole);
                }
                else//Admin rol atama
                {
                    AppUserRole appUserRole = new AppUserRole()
                    {
                        AppUserID = user.ID,
                        RoleID = roles.FirstOrDefault(x => x.Name.Contains("Admin")).ID
                    };
                    await _writeAppUserRoleRepository.AddAsync(appUserRole);
                }
            }

            AccessToken accessToken = _tokenHelper.CreateToken(user, roles);
            return accessToken;
        }

        public async Task<AppUser> GetByActivationCodeAsync(Guid code)
        {
            AppUser appUser = await _readRepository.GetByFirstAsync(x => x.ActivationCode == code);

            if (appUser.IsLock == true)//Kullanıcı hesabındakı kilidi kaldırıyoruz.
            {
                appUser.IsLock = false;
                appUser.IncorrectEntry = 1;
            }
            else if (appUser.Active == false)//Kullanıcıyı activasyonunu tamamlıyoruz.
                appUser.Active = true;
            await UpdateAsync(appUser);

            return appUser;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _readRepository.GetByFirstAsync(x=>x.Email==email);
        }

        public async Task<AppUser> LoginAsync(AppUserLoginDto entity)
        {
            AppUser appUser = await GetByEmailAsync(entity.Email);

            if (appUser == null)
                throw new InvalidOperationException($"({entity.Email}) Kullanıcı Bulunamadı");
            else if (appUser.IncorrectEntry == 4 && appUser.IsLock == true)
                throw new InvalidOperationException($"({entity.Email}) Hesabınız Askıya alındı");

            //Kulanıcı gridigi Password'u Databaseden gelen PasswordHash ve PasswordSalt ile hashleyip kontrol ediyoruz.
            if (!HashingHelper.VerifyPasswordHash(entity.Password, appUser.PasswordHash, appUser.PasswordSalt))
            {
                appUser.IncorrectEntry++; //Şifre yanlış girildiyse 1 atırıyoruz.

                if (appUser.IncorrectEntry == 4)
                {
                    appUser.IsLock = true; //3 kere yanlış girilen kulanıcıyı Lock ediyoruz.
                    //DelayedJob.SendMailJob(appUser);//Mail Gönderiyoruz.
                    await UpdateAsync(appUser);//IsLock Güncelliyoruz
                    throw new InvalidOperationException($"Şifreniz 3 kez yanlış girildi Hesap Askıya alındı");
                }
                await UpdateAsync(appUser);//IncorrectEntry Günceliyoruz
                throw new InvalidOperationException($" Paralonanız Yanlış");
            }

            appUser.IncorrectEntry = 1;//Kullanıcı başarılı giriş yaptı ise IncorrectEntry Güncelliyoruz.
            appUser.LastActivty = DateTime.UtcNow;
            await UpdateAsync(appUser);

            return appUser;
        }

        public async Task<AppUser> RegisterAsync(AppUserRegisterDto registerDto)
        {
            AppUser appUser = await GetByEmailAsync(registerDto.Email);

            if (appUser != null)
                throw new InvalidOperationException($"({registerDto.Email}) Bu Email zaten Kayıtlı");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);

            AppUser user = new AppUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
            };

            try
            {
               await _writeAppUserRepository.AddAsync(user);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Register_Error  =>  {e.Message}");
            }
            return user;
        }

        public async Task UpdatePasswordAsync(Guid id, AppUserPasswordUpdateDto entity)
        {
            AppUser appUser = await _readAppUserRepository.GetByIDAsync(id);
            if (appUser == null) 
                throw new InvalidOperationException($"({id}) Kullanıcı Bulunamadı");

            if (!HashingHelper.VerifyPasswordHash(entity.OldPassword, appUser.PasswordHash, appUser.PasswordSalt))
                throw new InvalidOperationException($" Parolanız Yanlış");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(entity.NewPassword, out passwordHash, out passwordSalt);

            appUser.PasswordHash = passwordHash;
            appUser.PasswordSalt = passwordSalt;

            await UpdateAsync(appUser);
        }
    }
}
