using UnityEngine.EventSystems;

public class Rook : ChessPiece, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ChessManager.chessRunning && ConnectionManager.player.playerTurn)
        {
            if (CancelPiece(false)) return;

            ChessManager.selectedPiece = gameObject.name;
            ChessManager.blockReset?.Invoke();
            ResetAntiDiagonally();

            int step = 1;
            while (step < 8)
            {
                MoveAntiDiagonally(step, false);
                step++;
            }

            ChessManager.pieceSelect?.Invoke(gameObject.name);
        }

        if (!ConnectionManager.player.playerTurn) EventManager.current.DisplayToast("Please Wait for Your Turn");
    }
}