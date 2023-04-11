using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace PureTruthApi.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
            IRepository<Analysis> Analysis { get; }
            IRepository<AnalysisTextile> AnalysisTextile { get; }
            IRepository<Bodyanalysischart> BodyAnalysisChart { get; }
            IRepository<Burialmain> BurialMain { get; }
            IRepository<BurialmainBodyanalysischart> BurialMainBodyAnalysisChart { get; }
            IRepository<BurialmainTextile> BurialMainTextile { get; }
            IRepository<Color> Color { get; }
            IRepository<ColorTextile> ColorTextile { get; }
            IRepository<Decoration> Decoration { get; }
            IRepository<DecorationTextile> DecorationTextile { get; }
            IRepository<Dimension> Dimension { get; }
            IRepository<DimensionTextile> DimensionTextile { get; }
            IRepository<Photodatum> PhotoData { get; }
            IRepository<PhotodataTextile> PhotoDataTextile { get; }
            IRepository<Photoform> PhotoForm { get; }
            IRepository<Structure> Structure { get; }
            IRepository<StructureTextile> StructureTextile { get; }
            IRepository<Teammember> TeamMember { get; }
            IRepository<Textile> Textile { get; }
            IRepository<Textilefunction> TextileFunction { get; }
            IRepository<TextilefunctionTextile> TextileFunctionTextile { get; }
            IRepository<Yarnmanipulation> YarnManipulation { get; }
            IRepository<YarnmanipulationTextile> YarnManipulationTextile { get; }
            int Complete();
        

    }
}
