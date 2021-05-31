
using System.Collections;

public class Helper
{
    public static string Player = "Player";
    public static string PlayerAnimation = "PlayerAnimation";
    public static string Target = "Target";
    public static string Block = "Block";
    public static string Blast = "Blast Effect";
    public static string Board = "Board";
}

public enum GameState
{
    GameIdle,
    GamePlay,
    GameOver
}

public enum PlayerType
{
    Player,
    Block
}

public enum TargetPlace
{
    Up,
    Down
}

public enum BlockPosState
{
    Left,
    Right
}



