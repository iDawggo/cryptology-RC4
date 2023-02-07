using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace RC4_Algorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int[] ksaArray = new int[256]; //Array for KSA
        public String key;          //
        public String plainTxt;     // Global variables for key, plain, and cipher text
        public String cipherTxt;    //

        private void inKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Updates the key global var
            key = inKey.Text;
        }

        private void scrllPlainTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            plainTxt = scrllPlainInput.Text;

            outKey.Text = "";           //
            scrllOutCipher.Text = "";   // Resets other text boxes around
            scrllCipherInput.Text = ""; // the program to avoid conflicts
            scrllOutPlain.Text = "";    //
            outPlainErrors.Text = "";   //
            outCipherErrors.Text = "";  //
            
            // Checks if a key exists
            if (key != null)
            {
                // Use KSA method
                KSA(ksaArray);

                // PRGA Algorithm
                int prga1 = 0;
                int prga2 = 0;
                for (int i = 0; i < plainTxt.Length; i++)
                {
                    prga1 = (prga1 + 1) % 256;
                    prga2 = (prga2 + ksaArray[prga1]) % 256;
                    swap(ksaArray, prga1, prga2);
                    int keyStream = ksaArray[(ksaArray[prga1] + ksaArray[prga2]) % 256];
                    outKey.Text += keyStream.ToString("X2");

                    // XOR function of the keystream with each character
                    char c = plainTxt[i];
                    int xor = keyStream ^ (int)c;

                    // Appending cipher output with each hexadecimal character
                    scrllOutCipher.Text += xor.ToString("X2");
                }
            }
            else
            {
                outPlainErrors.Text = "No keyword! Please enter a keyword in the box on the top! \nAfter entering a keyword, modify your plaintext again.";
            }
        }
        private void scrllCipherTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            cipherTxt = scrllCipherInput.Text;

            outKey.Text = "";           //
            scrllOutPlain.Text = "";    // Resets other text boxes around
            scrllPlainInput.Text = "";  // the program to avoid conflicts
            scrllOutCipher.Text = "";   //
            outPlainErrors.Text = "";   //
            outCipherErrors.Text = "";  //

            // Restricts input to hexadecimal characters
            foreach (char c in cipherTxt)
            { 
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')) && cipherTxt != String.Empty)
                {
                    scrllCipherInput.Text = cipherTxt.Remove(cipherTxt.Length - 1, 1);
                    scrllCipherInput.SelectionStart = scrllCipherInput.Text.Length;
                }
            }

            // Checks if a key exists OR if the ciphertext is uneven
            if (key == null)
            {
                outCipherErrors.Text = "No keyword! Please enter a keyword in the box on the top! \nAfter entering a keyword, modify your ciphertext again.";
            }
            else if (cipherTxt.Length % 2 != 0)
            {
                outCipherErrors.Text = "Ciphertext is uneven! Check your ciphertext to see if it's correct because it's not right now!!!";
            }
            else
            {
                // Use KSA method
                KSA(ksaArray);

                // Creating and filling an array for each hexadecimal pair
                String[] pairs = new string[cipherTxt.Length / 2];
                int count = 0; // counter for number of hexadecimal characters (pairs of hex nums)
                for (int i = 0; i < cipherTxt.Length; i += 2)
                {
                    pairs[count] = cipherTxt[i].ToString() + cipherTxt[i + 1].ToString();
                    count++;
                }

                // PRGA Algorithm
                int prga1 = 0; // "i" in PRGA Pseudocode
                int prga2 = 0; // "j" in PRGA Pseudocode
                for (int i = 0; i < cipherTxt.Length / 2; i++)
                {
                    prga1 = (prga1 + 1) % 256;
                    prga2 = (prga2 + ksaArray[prga1]) % 256;
                    swap(ksaArray, prga1, prga2);
                    int keyStream = ksaArray[(ksaArray[prga1] + ksaArray[prga2]) % 256];
                    outKey.Text += keyStream.ToString("X2");

                    // Converts each hexadecimal pair back into an int
                    int pair = Convert.ToInt32(pairs[i], 16);

                    // XOR function of the keystream with each character
                    int xor = keyStream ^ pair;

                    // Appending plain text output with every ASCII character
                    scrllOutPlain.Text += (char)xor;
                }
            }
        }

        public void KSA(int[] array)
        {
            // Fills array for KSA
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            //KSA Algorithm
            int ksa = 0; // "j" in KSA Pseudocode
            for (int i = 0; i < 256; i++)
            {
                ksa = (ksa + array[i] + key[i % key.Length]) % 256;
                swap(array, i, ksa);
            }
        }

        public void swap(int[] array, int a, int b)
        {
            int temp = array[b];
            array[b] = array[a];
            array[a] = temp;
        }
    }
}