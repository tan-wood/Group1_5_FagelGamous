using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace PureTruthApi.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
            IRepository<Analysis> Analysis { get; }
            IRepository<AnalysisTextile> AnalysisTextile { get; }
            IRepository<Artifactfagelgamousregister> ArtifactFagelgamousRegister { get; }
            IRepository<ArtifactfagelgamousregisterBurialmain> ArtifactFagelgamousRegisterBurialMain { get; }
            IRepository<Artifactkomaushimregister> ArtifactKomaushimRegister { get; }
            IRepository<ArtifactkomaushimregisterBurialmain> ArtifactKomaushimRegisterBurialMain { get; }
            IRepository<Biological> Biological { get; }
            IRepository<BiologicalC14> BiologicalC14 { get; }
            IRepository<Bodyanalysischart> BodyAnalysisChart { get; }
            IRepository<Book> Books { get; }
            IRepository<Burialmain> BurialMain { get; }
            IRepository<BurialmainBiological> BurialMainBiological { get; }
            IRepository<BurialmainBodyanalysischart> BurialMainBodyAnalysisChart { get; }
            IRepository<BurialmainCranium> BurialMainCranium { get; }
            IRepository<BurialmainTextile> BurialMainTextile { get; }
            IRepository<C14> C14 { get; }
            IRepository<Color> Color { get; }
            IRepository<ColorTextile> ColorTextile { get; }
            IRepository<Cranium> Cranium { get; }
            IRepository<Decoration> Decoration { get; }
            IRepository<DecorationTextile> DecorationTextile { get; }
            IRepository<Dimension> Dimension { get; }
            IRepository<DimensionTextile> DimensionTextile { get; }
            IRepository<Newsarticle> NewsArticle { get; }
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
