using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class Form1 : Form
    {
        //
        // Global変数
        //
        public static class Global
        {
            public static List<int> Numbers = new List<int>(Enumerable.Range(1, 75));                                               // 選対象の数字の配列
            public static int cnt = Numbers.Count;                                                                                  // Numbersのリストの要素数(LengthはArray用)
            public static int[] num_previous = new int[5] { 0, 0, 0, 0, 0 };                                                        // 履歴を出すための配列
            public static int select = 0;                                                                                           // 選んだ番号
            public const int fast_select_times = 39;                                                                                // 早く選んでる風の時の繰り返し回数
            public const int fast_select_time = 50;                                                                                 // 早く選んでる風の時の間隔(ミリ秒単位)
            public const int slow_select_times = 5;                                                                                 // 遅く選んでる風の時の繰り返し回数
            public const int slow_select_time = 250;                                                                                // 遅く選んでる風の時の間隔(ミリ秒単位)
            public const int final_select_time = 500;                                                                               // 数字が決定するまでの時の間隔(ミリ秒単位)
            public const int color_change_time = 500;                                                                               // 決定後の背景色が変わる時の間隔(ミリ秒単位)
            public const int color_change_times = 3;                                                                                // 決定後のエフェクトの繰り返し回数
            public readonly static List<string> rgb = new List<string> { "#E55381", "#5DA9E9", "#F4D53E", "#17B890", "#FFFFFF" };   // B, I, N, G, O 列の色(HTMLカラーコード)
            public readonly static List<string> rgb_code = new List<string> { "#000000", "#FF0000", "#00FF00", "#FFFF00" };         // Black, Red, Green, Yellow(HTMLカラーコード)
            private static readonly string exeDirPath = Path.GetDirectoryName(Application.ExecutablePath);                          // 実行したときの自身のフォルダパスを取得
            public static bool rollExists = false;                                                                                  // ロール音のファイルのフラグ
            public static string rollFilepath = exeDirPath + "\\drumroll.wav";                                                      // ロール音のファイルパス
            public static bool hitExists = false;                                                                                   // ヒット音のファイルのフラグ
            public static string hitFilepath = exeDirPath + "\\drumhit.wav";                                                        // ヒット音のファイルパス
        }

        private System.Media.SoundPlayer drumRoll, drumHit;                                                                         // SoundPlayerオブジェクトの使用


        //
        // ウィンドウの表示
        //
        public Form1()
        {
            InitializeComponent();                                                                                                  // GUIウィンドウの描画処理
        }


        //
        // 対応する番号のセルの色変更
        //
        private void tableColorChanger(int target)
        {
            switch (target)
            {
                case 0:
                    break;
                case 1:
                    num_1.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_1.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 2:
                    num_2.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_2.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 3:
                    num_3.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_3.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 4:
                    num_4.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_4.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 5:
                    num_5.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_5.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 6:
                    num_6.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_6.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 7:
                    num_7.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_7.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 8:
                    num_8.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_8.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 9:
                    num_9.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_9.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 10:
                    num_10.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_10.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 11:
                    num_11.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_11.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 12:
                    num_12.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_12.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 13:
                    num_13.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_13.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 14:
                    num_14.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_14.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 15:
                    num_15.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_15.ForeColor = ColorTranslator.FromHtml(Global.rgb[0]);
                    break;
                case 16:
                    num_16.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_16.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 17:
                    num_17.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_17.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 18:
                    num_18.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_18.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 19:
                    num_19.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_19.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 20:
                    num_20.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_20.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 21:
                    num_21.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_21.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 22:
                    num_22.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_22.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 23:
                    num_23.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_23.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 24:
                    num_24.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_24.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 25:
                    num_25.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_25.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 26:
                    num_26.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_26.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 27:
                    num_27.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_27.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 28:
                    num_28.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_28.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 29:
                    num_29.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_29.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 30:
                    num_30.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_30.ForeColor = ColorTranslator.FromHtml(Global.rgb[1]);
                    break;
                case 31:
                    num_31.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_31.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 32:
                    num_32.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_32.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 33:
                    num_33.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_33.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 34:
                    num_34.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_34.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 35:
                    num_35.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_35.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 36:
                    num_36.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_36.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 37:
                    num_37.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_37.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 38:
                    num_38.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_38.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 39:
                    num_39.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_39.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 40:
                    num_40.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_40.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 41:
                    num_41.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_41.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 42:
                    num_42.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_42.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 43:
                    num_43.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_43.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 44:
                    num_44.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_44.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 45:
                    num_45.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_45.ForeColor = ColorTranslator.FromHtml(Global.rgb[2]);
                    break;
                case 46:
                    num_46.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_46.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 47:
                    num_47.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_47.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 48:
                    num_48.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_48.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 49:
                    num_49.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_49.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 50:
                    num_50.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_50.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 51:
                    num_51.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_51.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 52:
                    num_52.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_52.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 53:
                    num_53.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_53.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 54:
                    num_54.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_54.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 55:
                    num_55.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_55.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 56:
                    num_56.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_56.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 57:
                    num_57.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_57.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 58:
                    num_58.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_58.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 59:
                    num_59.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_59.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 60:
                    num_60.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_60.ForeColor = ColorTranslator.FromHtml(Global.rgb[3]);
                    break;
                case 61:
                    num_61.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_61.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 62:
                    num_62.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_62.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 63:
                    num_63.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_63.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 64:
                    num_64.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_64.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 65:
                    num_65.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_65.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 66:
                    num_66.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_66.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 67:
                    num_67.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_67.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 68:
                    num_68.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_68.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 69:
                    num_69.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_69.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 70:
                    num_70.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_70.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 71:
                    num_71.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_71.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 72:
                    num_72.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_72.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 73:
                    num_73.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_73.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 74:
                    num_74.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_74.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                case 75:
                    num_75.BackColor = ColorTranslator.FromHtml(Global.rgb_code[0]);
                    num_75.ForeColor = ColorTranslator.FromHtml(Global.rgb[4]);
                    break;
                default:
                    char_b.Text = "E";
                    char_i.Text = "R";
                    char_n.Text = "R";
                    char_g.Text = "O";
                    char_o.Text = "R";
                    break;
            }
        }


        //
        // 選ぶときのエフェクト
        //
        private async void selectEffect()
        {
            int num;
            int[] array = Global.Numbers.OrderBy(i => Guid.NewGuid()).ToArray();                                                    // Global.Numbers配列をランダムに入れ替える
            Random random = new Random();                                                                                           // 乱数生成の準備

            for (int i = 0; i < Global.fast_select_times; i++)                                                                      // 早く選んでいる風の処理
            {
                int rand = random.Next(0, Global.cnt);
                number.Text = array[rand].ToString();                                                                               // 数字表示
                await Task.Delay(Global.fast_select_time);                                                                          // 待機処理
            }

            for (int i = 0; i < Global.slow_select_times; i++)                                                                      // 遅く選んでいる風の処理
            {
                int rand = random.Next(0, Global.cnt);
                number.Text = array[rand].ToString();
                await Task.Delay(Global.slow_select_time);
            }

            num = array[random.Next(0, Global.cnt)];                                                                                // 番号の決定
            await Task.Delay(Global.final_select_time);

            if (Global.rollExists == true)
            {
                drumRoll.Stop();                                                                                                    // ドラムロールの停止
            }

            if (Global.hitExists == true)
            {
                drumHit.Play();                                                                                                     // ドラムを叩く音声の再生
            }

            number.Text = num.ToString();                                                                                           // 決定した番号を表示


            for (int i = 0; i < Global.color_change_times; i++)                                                                     // 決定したことをアナウンス
            {
                number.BackColor = ColorTranslator.FromHtml(Global.rgb_code[1]);
                await Task.Delay(Global.color_change_time);
                number.BackColor = ColorTranslator.FromHtml(Global.rgb_code[2]);
                await Task.Delay(Global.color_change_time);
                number.BackColor = ColorTranslator.FromHtml(Global.rgb_code[3]);
                await Task.Delay(Global.color_change_time);
            }

            tableColorChanger(num);                                                                                                 // 対応する番号のセルの色を変更

            if (Global.hitExists == true)
            {
                drumHit.Stop();                                                                                                     // ドラムを叩く音声の停止
            }

            number.BackColor = SystemColors.Control;                                                                                // アナウンス終了(背景色を初期値へ)

            Global.select = num;                                                                                                    // Globalへ値をコピー
            Global.Numbers.Remove(num);                                                                                             // 選んだ番号に対応する要素を削除
            Global.cnt--;                                                                                                           // リストの長さを短くする

            for (int i = 4; i > 0; i--)
                Global.num_previous[i] = Global.num_previous[i - 1];                                                                // 履歴の更新処理

            roulette_btn.Enabled = true;                                                                                            // Nextボタンを有効化
        }


        //
        // Nextボタンクリック時動作
        //
        private void btnClick(object sender, EventArgs e)
        {
            roulette_btn.Enabled = false;                                                                                           // Nextボタンの無効化

            previous_1.Text = "Previous 1";                                                                                         // 履歴への表示変更
            previous_2.Text = "2";
            previous_3.Text = "3";
            previous_4.Text = "4";
            previous_5.Text = "5";

            if (Global.cnt == 0)                                                                                                    // すべての番号が出た時の処理
            {
                MessageBox.Show("すべての番号が出揃いました。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                  // Exclamationポップアップを表示
                Environment.Exit(0);                                                                                                // コード0x00で正常終了
            }
            else if (Global.cnt == 75)                                                                                              // 最初のクリック時の処理
            {
                roulette_btn.Text = "Next";                                                                                         // ボタンのテキストを変更
                number.Font = new Font("Meiryo UI", 403F);                                                                          // サイズの変更
                number.Text = "GO";                                                                                                 // 一瞬だけ「GO」と表示
                Global.rollExists = File.Exists(Global.rollFilepath);
                Global.hitExists = File.Exists(Global.hitFilepath);
                if (Global.rollExists == true)
                {
                    drumRoll = new System.Media.SoundPlayer(Global.rollFilepath);
                }
                if (Global.hitExists == true)
                {
                    drumHit = new System.Media.SoundPlayer(Global.hitFilepath);
                }
            }

            Global.num_previous[0] = Global.select;                                                                                 // Global.Select(初回は0、以降は選ばれた数字)
            previous_1_data.Text = Global.num_previous[0].ToString();                                                               // Arrayのデータを表示
            previous_2_data.Text = Global.num_previous[1].ToString();
            previous_3_data.Text = Global.num_previous[2].ToString();
            previous_4_data.Text = Global.num_previous[3].ToString();
            previous_5_data.Text = Global.num_previous[4].ToString();

            if (Global.rollExists == true)
            {
                drumRoll.Play();
            }
            selectEffect();                                                                                                         // 数字を選ぶ(非同期プロセス)
        }
    }
}
