using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace proyectostegna
{
    public partial class Form1 : Form
    {
        private Bitmap image1; // Primera imagen
        private Bitmap image2;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image1;
            }
        }

        private void abrirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image2 = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image = image2;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen|*.bmp;*.jpg;*.jpeg;*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog.FileName);
                MessageBox.Show("Imagen guardada exitosamente.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (image1 != null && image2 != null)
            {
                // Realizar la esteganografía
                Bitmap steganographyImage = HideImage(image1, image2);

                // Mostrar la imagen esteganográfica en el pictureBox3 sin aplicar el filtro Sobel
                pictureBox3.Image = steganographyImage;
            }
            else
            {
                MessageBox.Show("Por favor, carga dos imágenes primero.");
            }
        }

        private Bitmap HideImage(Bitmap carrierImage, Bitmap secretImage)
        {
            if (carrierImage.Width < secretImage.Width || carrierImage.Height < secretImage.Height)
            {
                throw new ArgumentException("La imagen portadora debe tener al menos el mismo tamaño que la imagen secreta.");
            }

            Bitmap result = new Bitmap(carrierImage);

            for (int y = 0; y < secretImage.Height; y++)
            {
                for (int x = 0; x < secretImage.Width; x++)
                {
                    Color carrierPixel = carrierImage.GetPixel(x, y);
                    Color secretPixel = secretImage.GetPixel(x, y);

                    // Modificar los bits menos significativos de los componentes de color de la imagen portadora
                    int newR = (carrierPixel.R & 0xFE) | ((secretPixel.R >> 7) & 0x01);
                    int newG = (carrierPixel.G & 0xFE) | ((secretPixel.G >> 7) & 0x01);
                    int newB = (carrierPixel.B & 0xFE) | ((secretPixel.B >> 7) & 0x01);

                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }

            return result;
        }
        private Bitmap GaussianBlur(Bitmap image, int kernelSize, double sigma)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            // Construir el kernel gaussiano
            double[,] kernel = new double[kernelSize, kernelSize];
            double kernelSum = 0;

            int halfKernelSize = kernelSize / 2;

            for (int i = -halfKernelSize; i <= halfKernelSize; i++)
            {
                for (int j = -halfKernelSize; j <= halfKernelSize; j++)
                {
                    kernel[i + halfKernelSize, j + halfKernelSize] = Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)) / (2 * Math.PI * sigma * sigma);
                    kernelSum += kernel[i + halfKernelSize, j + halfKernelSize];
                }
            }

            // Normalizar el kernel
            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    kernel[i, j] /= kernelSum;
                }
            }

            // Aplicar convolución con el kernel gaussiano
            for (int y = halfKernelSize; y < image.Height - halfKernelSize; y++)
            {
                for (int x = halfKernelSize; x < image.Width - halfKernelSize; x++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int i = -halfKernelSize; i <= halfKernelSize; i++)
                    {
                        for (int j = -halfKernelSize; j <= halfKernelSize; j++)
                        {
                            Color pixel = image.GetPixel(x + j, y + i);
                            double weight = kernel[i + halfKernelSize, j + halfKernelSize];

                            r += pixel.R * weight;
                            g += pixel.G * weight;
                            b += pixel.B * weight;
                        }
                    }

                    result.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return result;
        }

        private Bitmap SobelFilter(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            // Aplicar suavizado gaussiano
            Bitmap smoothedImage = GaussianBlur(image, 3, 1.4); // Puedes ajustar el tamaño del kernel y la desviación estándar según sea necesario

            // Definir los kernels Sobel
            int[,] sobelHorizontal = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelVertical = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < smoothedImage.Height - 1; y++)
            {
                for (int x = 1; x < smoothedImage.Width - 1; x++)
                {
                    int gx = 0;
                    int gy = 0;

                    // Calcular gradientes en las direcciones x e y
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = smoothedImage.GetPixel(x + j, y + i);
                            int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);

                            gx += sobelHorizontal[i + 1, j + 1] * grayValue;
                            gy += sobelVertical[i + 1, j + 1] * grayValue;
                        }
                    }

                    // Calcular la magnitud del gradiente
                    int magnitude = Math.Abs(gx) + Math.Abs(gy);
                    magnitude = Math.Min(255, magnitude);

                    // Si el píxel original era negro, lo dejamos casi negro
                    if (smoothedImage.GetPixel(x, y).GetBrightness() < 0.01)
                    {
                        result.SetPixel(x, y, Color.FromArgb(1, 1, 1)); // Color casi negro
                    }
                    else
                    {
                        result.SetPixel(x, y, smoothedImage.GetPixel(x, y));
                    }

                    // Si el borde es lo suficientemente fuerte, lo destacamos
                    if (magnitude > 100) // Ajusta el umbral según tus necesidades
                    {
                        result.SetPixel(x, y, Color.Red);
                    }
                }
            }

            return result;

        }
        private Bitmap RevealImage(Bitmap steganographyImage)
        {
            Bitmap result = new Bitmap(steganographyImage.Width, steganographyImage.Height);

            for (int y = 0; y < steganographyImage.Height; y++)
            {
                for (int x = 0; x < steganographyImage.Width; x++)
                {
                    Color stegoPixel = steganographyImage.GetPixel(x, y);

                    // Extraer los bits menos significativos de los componentes de color
                    int secretR = (stegoPixel.R & 0x01) << 7;
                    int secretG = (stegoPixel.G & 0x01) << 7;
                    int secretB = (stegoPixel.B & 0x01) << 7;

                    // Reconstruir el píxel original de la imagen secreta
                    Color secretColor = Color.FromArgb(secretR, secretG, secretB);

                    result.SetPixel(x, y, secretColor);
                }
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap selectedImage = null;

            if (pictureBox1.Image != null)
            {
                selectedImage = (Bitmap)pictureBox1.Image;
            }
            else if (pictureBox2.Image != null)
            {
                selectedImage = (Bitmap)pictureBox2.Image;
            }
            else
            {
                MessageBox.Show("Por favor, carga una imagen en pictureBox1 o pictureBox2 para procesar.");
                return;
            }

            // Aplicar filtro de Sobel solo para revelar la imagen oculta
            Bitmap revealedImage = RevealImage(selectedImage);
            pictureBox3.Image = revealedImage;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap selectedImage = null;

            if (pictureBox1.Image != null)
            {
                selectedImage = (Bitmap)pictureBox1.Image;
            }
            else if (pictureBox2.Image != null)
            {
                selectedImage = (Bitmap)pictureBox2.Image;
            }
            else
            {
                MessageBox.Show("Por favor, carga una imagen en pictureBox1 o pictureBox2 para procesar.");
                return;
            }

            // Aplicar filtro de Sobel solo para revelar la imagen oculta
            Bitmap revealedImage = RevealImage(selectedImage);
            pictureBox3.Image = SobelFilter(revealedImage);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private Bitmap HideMessage(Bitmap image, string message)
        {
            Bitmap result = new Bitmap(image);

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            int messageLength = messageBytes.Length;

            int byteIndex = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // Ocultar el bit del mensaje en los componentes R, G y B del píxel
                    if (byteIndex < messageLength)
                    {
                        byte newR = (byte)((pixel.R & 0xFE) | ((messageBytes[byteIndex] >> 7) & 0x01));
                        byte newG = (byte)((pixel.G & 0xFE) | ((messageBytes[byteIndex] >> 6) & 0x01));
                        byte newB = (byte)((pixel.B & 0xFE) | ((messageBytes[byteIndex] >> 5) & 0x01));

                        result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                        byteIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (byteIndex >= messageLength)
                {
                    break;
                }
            }

            return result;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (image1 != null && textBox1.Text != "")
            {
                string message = textBox1.Text;
                image1 = HideMessage(image1, message);
                pictureBox3.Image = image1;
            }
            else
            {
                MessageBox.Show("Por favor, carga una imagen en pictureBox1 y escribe un mensaje en el textBox1.");
            }
        }
        private string ExtractMessage(Bitmap image)
        {
            StringBuilder message = new StringBuilder();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // Extraer los bits menos significativos de los componentes R, G y B para formar el mensaje
                    byte extractedBitR = (byte)((pixel.R & 0x01) << 7);
                    byte extractedBitG = (byte)((pixel.G & 0x01) << 6);
                    byte extractedBitB = (byte)((pixel.B & 0x01) << 5);

                    // Combinar los bits extraídos en un solo byte y agregar el carácter al mensaje
                    byte extractedByte = (byte)(extractedBitR | extractedBitG | extractedBitB);
                    message.Append((char)extractedByte);
                }
            }

            return message.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (image1 != null)
            {
                string message = ExtractMessage(image1);
                MessageBox.Show("El mensaje oculto es:" + message);
            }
            else
            {
                MessageBox.Show("Por favor, carga una imagen en pictureBox1 para revelar el mensaje.");
            }
        }
    }
}
