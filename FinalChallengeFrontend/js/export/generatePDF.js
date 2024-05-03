/**
 * Converts an HTML table with class 'table-striped' into a PDF file and triggers a download.
 */
function generatePDF() {
  // Create a new jsPDF instance.
  const doc = new jspdf.jsPDF();

  // Select all row elements (tr) from the table.
  const rows = document.querySelectorAll(".table-striped tr");

  // Map each row to an array of its cell contents.
  const data = Array.from(rows).map((row, index) => {
    const cells = row.querySelectorAll("th, td");
    return Array.from(cells).map((cell) => cell.textContent);
  });

  // Extract headers from the data and format them for the PDF.
  const headers = data.shift().map((header) => ({
    header,
    dataKey: header.toLowerCase().replace(/\s+/g, ""),
  }));

  // Add a title to the PDF.
  doc.text("Sales Report", 14, 20);

  // Use the autoTable plugin to add the table to the PDF with specified options.
  doc.autoTable({
    startY: 30,
    columns: headers,
    body: data,
    theme: "striped",
    tableWidth: "auto",
    styles: { fontSize: 7, cellPadding: 2, overflow: "linebreak" },
    columnStyles: {
      productName: { cellWidth: 40 },
      productCategory: { cellWidth: 35 },
      totalSales: { cellWidth: 25 },
      percentContributionByCategoryAndRegion: { cellWidth: 35 },
      percentContributionByRegion: { cellWidth: 25 },
      orderDate: { cellWidth: "wrap" },
    },
    headStyles: { fillColor: [22, 160, 133] },
    margin: { top: 25, right: 10, left: 10 },
  });

  // Save the created PDF with the given filename.
  doc.save("sales_report.pdf");
}

// Attach an event listener to the button with class 'btn-pdf' to trigger PDF generation on click.
document.querySelector(".btn-pdf").addEventListener("click", generatePDF);
