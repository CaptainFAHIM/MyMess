using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp;

namespace MyMess
{
    public partial class ToLetForm : Form
    {
        private string _messName;

        public ToLetForm()
        {
            InitializeComponent();
        }

        public ToLetForm(string messName)
        {
            InitializeComponent();
            _messName = messName;
        }

        private void addAmmountBtn_Click(object sender, EventArgs e)
        {
            string seatNumber = seatTxt.Text.Trim();
            string contactNumber = contactTxt.Text.Trim();
            string location = locationTxt.Text.Trim();
            string gender = null;

            if (maleRadioBtn.Checked)
            {
                gender = maleRadioBtn.Text;
            }
            else if (femaleRadioBtn.Checked)
            {
                gender = femaleRadioBtn.Text;
            }

            if (string.IsNullOrEmpty(seatNumber) || string.IsNullOrEmpty(contactNumber) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveToLetAsPdf(seatNumber, contactNumber, location, gender);
        }

        private void SaveToLetAsPdf(string seatNumber, string contactNumber, string location, string gender)
        {
            try
            {
                // Open SaveFileDialog for the user to select the save location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Save To-Let PDF";
                    saveFileDialog.FileName = "ToLet.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Create and open the PDF document
                        Document document = new Document(iTextSharp.text.PageSize.A4);
                        PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                        document.Open();

                        // Add content to the PDF
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        // Define fonts
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        iTextSharp.text.Font contentFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font highlightFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD, BaseColor.RED);
                        iTextSharp.text.Font toLetFont = new iTextSharp.text.Font(bf, 36, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                        // Add title
                        Paragraph title = new Paragraph(_messName.Split('_')[0], titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        document.Add(title);

                        document.Add(new Paragraph("\n")); // Spacer

                        // Add TO-LET header
                        Paragraph toLet = new Paragraph("TO-LET", toLetFont);
                        toLet.Alignment = Element.ALIGN_CENTER;
                        document.Add(toLet);

                        document.Add(new Paragraph("\n")); // Spacer

                        // Add details
                        Paragraph details = new Paragraph($"( {seatNumber} Available Seat Here For {gender.ToUpper()} STUDENT)\nLocation: {location}\nContact: {contactNumber}\n ", contentFont);
                        details.Alignment = Element.ALIGN_LEFT;
                        document.Add(details);

                        document.Add(new Paragraph("\n\n", contentFont));

                        document.Close();

                        MessageBox.Show($"PDF saved successfully at {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
