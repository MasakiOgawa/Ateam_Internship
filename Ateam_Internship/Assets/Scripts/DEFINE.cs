using System.Collections;

//--------------------------------------------------
// ����		�萔��`�p�N���X
//			�X�N���v�g���܂����Œ萔���g���������ȂǂɎg�p
// ��`��	public const int GAME_MATCH_POINT = 3;
// �g�p��	DEFINE.GAME_MATCH_POINT
//--------------------------------------------------
public static class DEFINE
{
	public const int PUZZLE_PIECE_MAX = 39;     // �p�Y���̃s�[�X�̍ő吔

	//--------------------------------------------------
	// �񋓑̒�`
	//--------------------------------------------------

	// �p�Y���̃s�[�X�̏��
	public enum PUZZLE_PIECE_STATE
	{
		NONE = 0,       // �����Ȃ�
		PLAYER,         // �v���C���[
		ENEMY           // �G�l�~�[
	}


	// �p�Y���s�[�X�̕�
	public enum PUZZLE_PIECE_SUIT
	{
		NONE = 0,       // �����Ȃ�
		SPADE,          // �X�y�[�h
		DIAMOND,        // �_�C��
		HEART,          // �n�[�g
		CLUB,           // �N���u
	}

    // �Q�[�����
    public enum GAME_STATE
    {
        NONE = 0,           // �����Ȃ�
        PLAYER_TURN,        // �v���C���[
        ENEMY_TURN,         // �G�l�~�[
        PUZZLE_CLEAN,       // �p�Y���N���[��
    }
}
