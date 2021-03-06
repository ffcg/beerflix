﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Data.Beers.Common
{
    public class ExcelReaderInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ExcelReader<SystembolagetArticleRow>>()
                    .DependsOn(new {fileStreamPath = @"systembolaget.xlsx", workSheetName = @"AllaArtiklar"})
                    .LifestylePerWebRequest()
                );
        }
    }
}