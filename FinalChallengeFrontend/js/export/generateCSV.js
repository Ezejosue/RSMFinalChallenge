/**
 * Converts an HTML table with class 'table-striped' into a CSV file and triggers a download.
 */
function generateCSV() {
  // Select the table element.
  const table = document.querySelector(".table-striped");

  // Collect all row elements (tr) from the table.
  const rows = table.querySelectorAll("tr");

  // Map each row to an array of its cell values, removing commas to avoid CSV formatting issues.
  const csvContent = Array.from(rows).map((row) => {
    const cells = row.querySelectorAll("th, td");
    return Array.from(cells).map((cell) => cell.textContent.replace(/,/g, ""));
  });

  // Convert the array of rows and their cell contents into CSV format using PapaParse library.
  const csv = Papa.unparse(csvContent);

  // Create a Blob object representing the CSV file.
  var blob = new Blob([csv], { type: "text/csv;charset=utf-8" });

  // Use the FileSaver.js library's saveAs function to save the CSV file.
  saveAs(blob, "sales_report.csv");
}

// Attach an event listener to the button with class 'btn-csv' to trigger CSV generation on click.
document.querySelector(".btn-csv").addEventListener("click", generateCSV);
