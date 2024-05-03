// Adding event listeners for when the document is fully loaded.
document.addEventListener("DOMContentLoaded", function () {
  // Call functions to populate categories and territories in the dropdowns.
  loadCategories();
  loadTerritories();
});

/**
 * Fetches and loads category data into a dropdown list.
 */
function loadCategories() {
  // Perform a GET request to fetch category data.
  axios
    .get("https://localhost:7099/api/ProductCate")
    .then(function (response) {
      const categories = response.data;
      const categorySelect = document.getElementById("categoryName");

      // Iterate over each category and append it as an option in the dropdown.
      categories.forEach((category) => {
        const option = document.createElement("option");
        option.value = category.name;
        option.text = category.name;
        categorySelect.appendChild(option);
      });
    })
    .catch(function (error) {
      // Log an error if the request fails.
      console.error("Error loading categories:", error);
    });
}

/**
 * Fetches and loads territory data into a dropdown list.
 */
function loadTerritories() {
  // Perform a GET request to fetch territory data.
  axios
    .get("https://localhost:7099/api/SalesTerritory")
    .then(function (response) {
      const territories = response.data;
      const territorySelect = document.getElementById("territoryName");

      // Iterate over each territory and append it as an option in the dropdown.
      territories.forEach((territory) => {
        const option = document.createElement("option");
        option.value = territory.name;
        option.text = territory.name;
        territorySelect.appendChild(option);
      });
    })
    .catch(function (error) {
      // Log an error if the request fails.
      console.error("Error loading territories:", error);
    });
}
