namespace Chess.Renderers.Contracts
{
    using Chess.Board;

    public interface Irenderer
    {
        void RenderBoard(IBoard board);

        void RenderMainMenu();

        void PrintErrorMessage(string errorMessage);
    }
}
