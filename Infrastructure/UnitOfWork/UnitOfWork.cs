using Microsoft.EntityFrameworkCore;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using Group1_5_FagelGamous.Data;

namespace PureTruthApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
            private readonly MummyContext Context;

            public UnitOfWork(MummyContext context)
            {
                Context = context;
                BurialMain = new BurialMainRepository(Context);
                BurialMainBodyAnalysisChart = new BurialMainBodyAnalysisChartRepository(Context);
                BurialMainTextile = new BurialMainTextileRepository(Context);
                Color = new ColorRepository(Context);
                ColorTextile = new ColorTextileRepository(Context);
                Decoration = new DecorationRepository(Context);
                DecorationTextile = new DecorationTextileRepository(Context);
                Dimension = new DimensionRepository(Context);
                DimensionTextile = new DimensionTextileRepository(Context);
                PhotoData = new PhotoDataRepository(Context);
                PhotoDataTextile = new PhotoDataTextileRepository(Context);
                PhotoForm = new PhotoFormRepository(Context);
                Structure = new StructureRepository(Context);
                StructureTextile = new StructureTextileRepository(Context);
                TeamMember = new TeamMemberRepository(Context);
                Textile = new TextileRepository(Context);
                TextileFunction = new TextileFunctionRepository(Context);
                TextileFunctionTextile = new TextileFunctionTextileRepository(Context);
                YarnManipulation = new YarnManipulationRepository(Context);
                YarnManipulationTextile = new YarnManipulationTextileRepository(Context);
                Analysis = new AnalysisRepository(Context);
                AnalysisTextile = new AnalysisTextileRepository(Context);
                BodyAnalysisChart = new BodyAnalysisChartRepository(Context);
                Burialmain = new BurialMainRepository(Context);
            }

            public IRepository<Burialmain> BurialMain { get; private set; }

            public IRepository<BurialmainBodyanalysischart> BurialMainBodyAnalysisChart { get; private set; }

            public IRepository<BurialmainTextile> BurialMainTextile { get; private set; }

            public IRepository<Color> Color { get; private set; }

            public IRepository<ColorTextile> ColorTextile { get; private set; }

            public IRepository<Decoration> Decoration { get; private set; }

            public IRepository<DecorationTextile> DecorationTextile { get; private set; }

            public IRepository<Dimension> Dimension { get; private set; }

            public IRepository<DimensionTextile> DimensionTextile { get; private set; }

            public IRepository<Photodatum> PhotoData { get; private set; }
            public IRepository<PhotodataTextile> PhotoDataTextile { get; private set; }

            public IRepository<Photoform> PhotoForm { get; private set; }

            public IRepository<Structure> Structure { get; private set; }

            public IRepository<StructureTextile> StructureTextile { get; private set; }

            public IRepository<Teammember> TeamMember { get; private set; }

            public IRepository<Textile> Textile { get; private set; }

            public IRepository<Textilefunction> TextileFunction { get; private set; }

            public IRepository<TextilefunctionTextile> TextileFunctionTextile { get; private set; }

            public IRepository<Yarnmanipulation> YarnManipulation { get; private set; }

            public IRepository<YarnmanipulationTextile> YarnManipulationTextile { get; private set; }

            public IRepository<Analysis> Analysis { get; private set; }

            public IRepository<AnalysisTextile> AnalysisTextile { get; private set; }

            public IRepository<Bodyanalysischart> BodyAnalysisChart { get; private set; }

            public IRepository<Burialmain> Burialmain { get; private set; }


            public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
