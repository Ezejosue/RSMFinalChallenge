// An array to store data globally fetched from the API.
let GlobalData = [];

// A variable to track the current page number of the data being viewed.
let currentPage = 1;

/**
 * Fetches sales data based on employee and product filters, and handles pagination.
 * @param {number} PageNumber - The page number to fetch, defaults to 1.
 */
function fetchData(PageNumber = 1) {
  // Number of items per page.
  let pageSize = 50;

  // Fetch filters from the document.
  const employeeFilter = document.getElementById("employeeName").value;
  const productFilter = document.getElementById("productName").value;
  const startDate = document.getElementById("startDate").value;
  const endDate = document.getElementById("endDate").value;

  // Base URL for the API.
  let url = "https://localhost:7099/api/GetSalesByEmployee?";

  // Accumulate URL parameters based on available filters.
  const params = [];
  if (employeeFilter) {
    params.push(`employee=${encodeURIComponent(employeeFilter)}`);
  }
  if (productFilter) {
    params.push(`product=${encodeURIComponent(productFilter)}`);
  }
  if (startDate) {
    params.push(`startDate=${encodeURIComponent(startDate)}`);
  }
  if (endDate) {
    params.push(`endDate=${encodeURIComponent(endDate)}`);
  }

  // Add pagination parameters.
  params.push(`page=${PageNumber}`);
  params.push(`pageSize=${pageSize}`);

  // Complete URL by joining parameters.
  url += params.join("&");

  // Perform the GET request using axios.
  axios
    .get(url)
    .then((response) => {
      GlobalData = response.data;
      displayData(GlobalData);
    })
    .catch((error) => {
      console.error("Error fetching data:", error);
      document.getElementById("reportPreview").innerHTML =
        "<p>Error loading data!</p>";
    });
}

/**
 * Displays the fetched data in a HTML table.
 * @param {Array} GlobalData - The data to display in the table.
 */
function displayData(GlobalData) {
  let tableContent = `<h2>Sales By Employee</h2><p>Page Number: ${currentPage}</p>`;
  // Check if data is available and append each item to the table.
  if (GlobalData.length > 0) {
    tableContent += `
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Employee Name</th>
            <th>Category Name</th>
            <th>Product Name</th>
            <th>Sales Count</th>
            <th>Avg Unit Price</th>
            <th>Total Sales</th>
            <th>First Sale Date</th>
            <th>Last Sale Date</th>
          </tr>
        </thead>
        <tbody>`;

    GlobalData.forEach((item) => {
      tableContent += `
        <tr>
          <td>${item.employeeName}</td>
          <td>${item.categoryName}</td>
          <td>${item.productName}</td>
          <td>${item.salesCount}</td>
          <td>${item.avgUnitPrice}</td>
          <td>${item.totalSales}</td>
          <td>${item.firstSaleDate}</td>
          <td>${item.lastSaleDate}</td>
        </tr>`;
    });

    tableContent += `</tbody></table>`;
  } else {
    tableContent += "<p>No data available to display.</p>";
  }

  // Display the constructed table content in the document.
  document.getElementById("reportPreview").innerHTML = tableContent;
}

/**
 * Navigates to the next page of data.
 */
function nextPage() {
  currentPage++;
  fetchData(currentPage);
}

/**
 * Navigates to the previous page of data, if not on the first page.
 */
function previousPage() {
  if (currentPage > 1) {
    currentPage--;
    fetchData(currentPage);
  }
}
