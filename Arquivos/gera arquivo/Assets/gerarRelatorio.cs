using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;

public class gerarRelatorio : MonoBehaviour
{
   
    public void gerarArquivo(){
        // Document document = new Document(PageSize.A4);
        // document.SetMargins(3, 2, 3, 2);
        
        // string caminho = "/home/liss/Documentos/" + "Hello.pdf";

        // // PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Directory.GetCurrentDirectory() + "\\Hello.pdf", FileMode.Create));
        // PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminho, FileMode.Create));

        // document.Open();
        // PdfPTable table = new PdfPTable(3);

        // iTextSharp.text.Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22);

        // Paragraph coluna1 = new Paragraph("Nome", fonte);
        // Paragraph coluna2 = new Paragraph("Idade", fonte);
        // Paragraph coluna3 = new Paragraph("Cidade", fonte);
        
        // var cell1 = new PdfPCell();
        // var cell2 = new PdfPCell();
        // var cell3 = new PdfPCell();

        // cell1.AddElement(coluna1);
        // cell2.AddElement(coluna2);
        // cell3.AddElement(coluna3);

        // document.Add(table);
        // document.Close();

        Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
        doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
        doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf
            string caminho = "/home/liss/Documentos/" + "Hello.pdf";

            //criando o arquivo pdf embranco, passando como parametro a variavel doc criada acima e a variavel caminho
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados="";

            iTextSharp.text.Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22);

            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph(dados, fonte);
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            //Alinhamento Justificado
            //adicioando texto
            paragrafo.Add("TESTE TESTE TESTE");
            //acidionado paragrafo ao documento
            doc.Add(paragrafo);

            //Adicionando imagens 
            // doc.Add(new Paragraph("GIF")); //rotulo do gráfico

            string caminhoImg = Application.dataPath + "/capturas/" + "ola.png";

            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(caminhoImg);

            gif.ScalePercent(40f);
            gif.Alignment = Element.ALIGN_CENTER;

            doc.Add(gif);

            //fechando documento para que seja salva as alteraçoes.
            doc.Close();

    }

}
