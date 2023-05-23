using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.Autofact
{
    public class AutofactBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserRepository>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductRepository>().As<IProductDal>().SingleInstance();

            builder.RegisterType<ProductTypeManager>().As<IProductTypeService>().SingleInstance();
            builder.RegisterType<EfProductTypeRepository>().As<IProductTypeDal>().SingleInstance();

            builder.RegisterType<GrowingAreaManager>().As<IGrowingAreaService>().SingleInstance();
            builder.RegisterType<EfGrowingAreaRepository>().As<IGrowingAreaDal>().SingleInstance();

            builder.RegisterType<SoilTypeManager>().As<ISoilTypeService>().SingleInstance();
            builder.RegisterType<EfSoilTypeRepository>().As<ISoilTypeDal>().SingleInstance();

            builder.RegisterType<IrrigationTypeManager>().As<IIrrigationTypeService>().SingleInstance();
            builder.RegisterType<EfIrrigationTypeRepository>().As<IIrrigationTypeDal>().SingleInstance();

            builder.RegisterType<PlantationManager>().As<IPlantationService>().SingleInstance();
            builder.RegisterType<EfPlantationRepository>().As<IPlantationDal>().SingleInstance();

            base.Load(builder);
        }
    }
}
