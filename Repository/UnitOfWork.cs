using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repository.AuthenticationRepo;
using Repository.HistoryRepo;
using Repository.PriceRepo;
using Repository.TollboothRepo;
using SqlDatabase;
namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ToolboothContext _context;
        
        private IGenericRepository<Location> locationRepository;
        private ITollboothRepository tollboothRepository;
        private IGenericRepository<Category> categoryRepository;
        private IPriceRepository priceRepository;
        private IHistoryRepository historyRepository;
        private IAuthenticationRepository authenticationRepository;

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public UnitOfWork(ToolboothContext context,UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IHistoryRepository History
        {
            get
            {
                if (historyRepository == null)
                    historyRepository = new HistoryRepository(_context);
                return historyRepository;
            }
        }

        public IAuthenticationRepository Authentication
        {
            get
            {
                if (authenticationRepository == null)
                    authenticationRepository = new AuthenticationRepository(_context, _userManager,_signInManager);
                return authenticationRepository;
            }
        }

        public IPriceRepository Price
        {
            get
            {
                if (priceRepository == null)
                    priceRepository = new PriceRepository(_context);
                return priceRepository;
            }
        }

        public IGenericRepository<Category> Category 
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new GenericRepository<Category>(_context);
                return categoryRepository;
            }
        }

        public IGenericRepository<Location> Location
        {
            get 
            {
                if (this.locationRepository == null)
                    this.locationRepository =  new GenericRepository<Location>(_context);
                return this.locationRepository;
            }
        }

        public ITollboothRepository Tollbooth
        { 
            get
            {
                if (this.tollboothRepository == null)
                    tollboothRepository = new TollboothRepository(_context);
                return this.tollboothRepository;
            } 
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 1);
        }
    }
}
