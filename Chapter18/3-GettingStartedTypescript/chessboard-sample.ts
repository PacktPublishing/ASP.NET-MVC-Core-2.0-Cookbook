enum PieceColor {
    White = 1,
    Black = 2
}

enum PieceType {
    Pawn = 1,
    Bishop = 2,
    Knight = 3,
    Rook = 4,
    Queen = 5,
    King = 6
}

interface Piece {
    type: PieceType;
    color: PieceColor;
}

class Block {
    isEven: boolean;
    row: number;
    col: number;
    piece: Piece;
    constructor(row: number, col: number) {
        this.row = row;
        this.col = col;
        this.isEven = row % 2 ? !(col % 2) : !!(col % 2);
    }
}

class Board {
    blocks: Array<Block> = [];

    placePieceOnBoard(piece: Piece, row: number, col: number) {
        this.blocks[(row * 8) + (col * 8)].piece = piece;
    }
}

let game = new Board();
for (let iLoop = 0; iLoop < 8; iLoop++) {
    for (let yLoop = 0; yLoop < 8; yLoop++) {
        game.blocks.push(new Block(iLoop, yLoop));
    }
}
game.placePieceOnBoard({ color: PieceColor.White, type: PieceType.Pawn }, 1, 0);
game.placePieceOnBoard({ color: PieceColor.Black, type: PieceType.Pawn }, 7, 0);
// more code... removed for brevity