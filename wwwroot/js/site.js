function calculateBmi() {
    var heightInput = document.getElementById('height').value;
    var weightInput = document.getElementById('weight').value;

    var isValid = validateData(heightInput, weightInput)

    if (isValid) {
        var heightInMeters = heightInput / 100;

        var bmi = weightInput / (heightInMeters * heightInMeters);

        document.getElementById('resultOfBmi').innerHTML = "Your BMI is: " + Math.round(bmi * 100) / 100;

        const item = {
            bmiNumber: Math.round(bmi * 100) / 100
        };

        $.ajax({
            type: "POST",
            accepts: "application/json",
            url: "api/BmiCalculations",
            contentType: "application/json",
            data: JSON.stringify(item),
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Something went wrong");
            },
            success: function (result) {
                document.getElementById("resultOfPost").innerHTML = "Your BMI has been saved";
            }
        })
    }

}

function validateData(heightInput, weightInput) {
    if (heightInput === "") {
        document.getElementById('resultOfBmi').innerHTML = "Please input a valid height";
    }
    else if (weightInput === "") {
        document.getElementById('resultOfBmi').innerHTML = "Please input a valid weight";
    }
    else if (heightInput < 30 || heightInput > 270) {
        document.getElementById('resultOfBmi').innerHTML = "Please provide a height in cm between 30 and 270";
    }
    else {
        return true;
    }
}