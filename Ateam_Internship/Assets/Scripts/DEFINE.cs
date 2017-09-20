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
	// �񋓑̒�` (�z���g��DEFINE�Ƃ͕ʂ̃N���X�ɂ���ׂ�)
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

	//--------------------------------------------------
	// �\���̒�`  (�z���g��DEFINE�Ƃ͕ʂ̃N���X�ɂ���ׂ�)
	//--------------------------------------------------

	// �L�����N�^�[���\����
	public struct Character
	{
		public float Life;                         // ���C�t
		public float Attack;                       // �A�^�b�N
		public DEFINE.PUZZLE_PIECE_SUIT Skill1;    // �X�L���ɕK�v�ȃX�[�g1
		public DEFINE.PUZZLE_PIECE_SUIT Skill2;    // �X�L���ɕK�v�ȃX�[�g2

		public Character(float life, float attack, DEFINE.PUZZLE_PIECE_SUIT skill1, DEFINE.PUZZLE_PIECE_SUIT skill2)
		{
			Life = life;            // ���C�t
			Attack = attack;        // �A�^�b�N
			Skill1 = skill1;        // �X�L��1
			Skill2 = skill2;        // �X�L��2
		}
	}

	// �p�[�e�B���\����
	public struct Party
	{
		public Character Chara_0;      // ���[�_�[
		public Character Chara_1;      // �L����1(�A�C�R�� ��)
		public Character Chara_2;      // �L����2(�A�C�R�� ��)
		public Character Chara_3;      // �L����3(�A�C�R�� �E)

		// �R���X�g���N�^
		public Party(Character chara0, Character chara1, Character chara2, Character chara3)
		{
			Chara_0 = chara0;       // ���[�_�[
			Chara_1 = chara1;       // �L����1(�A�C�R�� ��)
			Chara_2 = chara2;       // �L����2(�A�C�R�� ��)
			Chara_3 = chara3;       // �L����3(�A�C�R�� �E)
		}
	};
}
