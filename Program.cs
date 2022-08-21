
using HR.DataBaseContext;
using HR.RepositoryContract;
using HR.RespositoryConcrete;
using HR.Services;
using Microsoft.EntityFrameworkCore;
using Ninject;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container be raveshe ninject
    //IKernel ninjectKernel=new StandardKernel();
    //ninjectKernel.Bind<IEmployeesRepository>().To<EmployeeRepository>();
    //ninjectKernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
//add repository
builder.Services.AddScoped(typeof(IBaseRepositories<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IEmployeesRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
//add service to the container.
builder.Services.AddDbContext<DataBaseDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app  = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

  app.Run(); 
