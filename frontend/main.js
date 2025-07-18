window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});

const functionApi = 'https://getresumecounter-bfe5cufmayh5dmdk.eastasia-01.azurewebsites.net/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 0;
    fetch(functionApi)
    .then(response => {
        console.log("Response status:", response.status);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json()
    })
    .then(response => {
        console.log("Website called function API.");
        console.log("Response data:", response);
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error) {
        console.log("Detailed error:", error);
        document.getElementById("counter").innerText = "Error loading";
    });
    return count;
}