// An array to store the global data fetched from the API.
let GlobalData = [];

// A variable to track the current page number of the data being viewed.
let currentPage = 1;

/**
 * Fetches data from the SalesReports API based on filters and pagination.
 * @param {number} PageNumber - The page number to fetch, defaults to 1.
 */
function fetchData(PageNumber = 1) {
  // Number of items per page.
  let pageSize = 50;

  // Fetch filters from the document.
  const categoryFilter = document.getElementById("categoryName").value;
  const regionFilter = document.getElementById("territoryName").value;
  const startDate = document.getElementById("startDate").value;
  const endDate = document.getElementById("endDate").value;

  // Base URL for the API.
  let url = "https://localhost:7099/api/SalesReport?";

  // Accumulate URL parameters based on available filters.
  const params = [];
  if (categoryFilter) {
    params.push(`categoryFilter=${encodeURIComponent(categoryFilter)}`);
  }
  if (regionFilter) {
    params.push(`regionFilter=${encodeURIComponent(regionFilter)}`);
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
  let tableContent = `<h2>Sales Data Preview</h2><p>Page Number: ${currentPage}</p>`;
  // Check if data is available and append each item to the table.
  if (GlobalData.length > 0) {
    tableContent += `
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Product Name</th>
            <th>Product Category</th>
            <th>Total Sales</th>
            <th>Percent Contribution by Category and Region</th>
            <th>Percent Contribution by Region</th>
            <th>Order Date</th>
          </tr>
        </thead>
        <tbody>`;

    GlobalData.forEach((item) => {
      tableContent += `
        <tr>
          <td>${item.productName}</td>
          <td>${item.productCategory}</td>
          <td>${item.totalSales}</td>
          <td>${item.percentContributionByCategoryAndRegion}</td>
          <td>${item.percentContributionByRegion}</td>
          <td>${item.orderDate}</td>
        </tr>`;
    });

    tableContent += `
        </tbody>
      </table>`;
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
