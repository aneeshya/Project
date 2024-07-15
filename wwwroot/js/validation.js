document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('employeeForm').addEventListener('submit', function (e) {
        var isValid = true;

        // Clear previous errors
        document.getElementById('nameError').innerText = '';
        document.getElementById('descriptionError').innerText = '';

        // Validate Name
        if (document.getElementById('Name').value.trim() === '') {
            document.getElementById('nameError').innerText = 'Name is required';
            isValid = false;
        }

        // Validate Description
        if (document.getElementById('Description').value.trim() === '') {
            document.getElementById('descriptionError').innerText = 'Description is required';
            isValid = false;
        }

        // Prevent form submission if not valid
        if (!isValid) {
            e.preventDefault();
        }
    });
});


