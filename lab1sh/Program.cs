using System;
using System.Collections.Generic;

public interface IChessPiece
{
    string GetName();
    string GetColor();
    void Display();
}

public class King : IChessPiece
{
    private string _color;

    public King(string color)
    {
        _color = color;
    }

    public string GetName() => "King";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} King.");
}

public class Queen : IChessPiece
{
    private string _color;

    public Queen(string color)
    {
        _color = color;
    }

    public string GetName() => "Queen";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} Queen.");
}

public class Rook : IChessPiece
{
    private string _color;

    public Rook(string color)
    {
        _color = color;
    }

    public string GetName() => "Rook";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} Rook.");
}

public class Bishop : IChessPiece
{
    private string _color;

    public Bishop(string color)
    {
        _color = color;
    }

    public string GetName() => "Bishop";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} Bishop.");
}

public class Knight : IChessPiece
{
    private string _color;

    public Knight(string color)
    {
        _color = color;
    }

    public string GetName() => "Knight";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} Knight.");
}

public class Pawn : IChessPiece
{
    private string _color;

    public Pawn(string color)
    {
        _color = color;
    }

    public string GetName() => "Pawn";
    public string GetColor() => _color;
    public void Display() => Console.WriteLine($"Displaying a {_color} Pawn.");
}

public interface IChessPieceFactory
{
    IChessPiece CreateChessPiece();
}

public class KingFactory : IChessPieceFactory
{
    private string _color;

    public KingFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new King(_color);
}

public class QueenFactory : IChessPieceFactory
{
    private string _color;

    public QueenFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new Queen(_color);
}

public class RookFactory : IChessPieceFactory
{
    private string _color;

    public RookFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new Rook(_color);
}

public class BishopFactory : IChessPieceFactory
{
    private string _color;

    public BishopFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new Bishop(_color);
}

public class KnightFactory : IChessPieceFactory
{
    private string _color;

    public KnightFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new Knight(_color);
}

public class PawnFactory : IChessPieceFactory
{
    private string _color;

    public PawnFactory(string color)
    {
        _color = color;
    }

    public IChessPiece CreateChessPiece() => new Pawn(_color);
}

public class ChessBoard
{
    private IChessPiece[,] board;

    public ChessBoard(int rows, int cols, List<IChessPieceFactory> factories)
    {
        board = new IChessPiece[rows, cols];
        SetupChessBoard(factories);
    }

    public void SetupChessBoard(List<IChessPieceFactory> factories)
    {
        int whiteKingCount = 0;
        int blackKingCount = 0;
        int whiteQueenCount = 0;
        int blackQueenCount = 0;
        int whiteKnightCount = 0;
        int blackKnightCount = 0;
        int whiteRookCount = 0;
        int blackRookCount = 0;
        int whiteBishopCount = 0;
        int blackBishopCount = 0;
        int whitePawnCount = 0;
        int blackPawnCount = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                IChessPieceFactory factory = factories[(i + j) % factories.Count];
                IChessPiece piece = factory.CreateChessPiece();

                if (piece.GetColor() == "White")
                {
                    if (piece.GetName() == "King")
                    {
                        if (whiteKingCount == 0)
                        {
                            whiteKingCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Queen")
                    {
                        if (whiteQueenCount == 0)
                        {
                            whiteQueenCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Knight")
                    {
                        if (whiteKnightCount < 2)
                        {
                            whiteKnightCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Rook")
                    {
                        if (whiteRookCount < 2)
                        {
                            whiteRookCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Bishop")
                    {
                        if (whiteBishopCount < 2)
                        {
                            whiteBishopCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Pawn")
                    {
                        if (whitePawnCount < 8)
                        {
                            whitePawnCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                }
                else if (piece.GetColor() == "Black")
                {
                    if (piece.GetName() == "King")
                    {
                        if (blackKingCount == 0)
                        {
                            blackKingCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Queen")
                    {
                        if (blackQueenCount == 0)
                        {
                            blackQueenCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Knight")
                    {
                        if (blackKnightCount < 2)
                        {
                            blackKnightCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Rook")
                    {
                        if (blackRookCount < 2)
                        {
                            blackRookCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Bishop")
                    {
                        if (blackBishopCount < 2)
                        {
                            blackBishopCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                    else if (piece.GetName() == "Pawn")
                    {
                        if (blackPawnCount < 8)
                        {
                            blackPawnCount++;
                        }
                        else
                        {
                            piece = factories[(i + j + 1) % factories.Count].CreateChessPiece();
                        }
                    }
                }

                board[i, j] = piece;
            }
        }
    }

    public void DisplayChessBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j].Display();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var factories = new List<IChessPieceFactory>
        {
            new KingFactory("White"),
            new QueenFactory("White"),
            new RookFactory("White"),
            new BishopFactory("White"),
            new KnightFactory("White"),
            new PawnFactory("White"),
            new KingFactory("Black"),
            new QueenFactory("Black"),
            new RookFactory("Black"),
            new BishopFactory("Black"),
            new KnightFactory("Black"),
            new PawnFactory("Black")
        };

        ChessBoard chessBoard = new ChessBoard(8, 8, factories);
        chessBoard.DisplayChessBoard();
    }
}
