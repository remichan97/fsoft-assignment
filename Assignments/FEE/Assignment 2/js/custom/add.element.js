$("#button-addon2").on("click", function () {
	$(".data").append('<input type="text" class="form-control reduced-width" id="question1" placeholder="Add an answer" aria-label="Add an answer" aria-describedby="button-addon2" required>');
});
$("#add-question").on("click", function () {
	var html = '<hr><div class="row mb-3"><div class="col-sm-2 col-form-label"></div><div class="col-sm-10"><input type="text" class="form-control" placeholder="Enter your question" required></div><div class="invalid-tooltip">Please enter a question to be asked</div></div><div class="row mb-3"><div class="col-sm-10 offset-sm-2"><div class="form-check"><input class="form-check-input" type="checkbox" id="gridCheck1"><label class="form-check-label" for="gridCheck1">Mandatory</label></div></div></div><div class="row mb-3"><div class="col-sm-10 offset-sm-2"><div class="form-check"><input class="form-check-input" type="checkbox" id="gridCheck1"><label class="form-check-label" for="gridCheck1">Participant can select multiple choices</label></div></div></div><div class="row"><label for="question1" class="col-sm-2 col-form-label">Possible answers</label><div class="col-sm-8"><div class="input-group"><input type="text" class="form-control" id="question1" placeholder="Add an answer" aria-label="Add an answer" aria-describedby="button-addon2" required><button class="btn btn-primary" type="button" id="button-addon2"><i class="fas fa-plus"></i></button></div><div class="data"></div></div><div class="invalid-tooltip">Please enter an answer</div></div>';
	$(".add-question-data").append(html);
});