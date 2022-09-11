$().ready(function () {
	$('.form-needs-validation').validate( {
		debug: true,
		errorClass: 'is-invalid',
		successClass: 'is-valid',
		rules: {
			pollname: {
				required: true,
				minlength: 3,
				maxlength: 255
			},
			question: {
				required: true,
				minlength: 3,
				maxlength: 255
			},
			answer: {
				required: true,
				minlength: 3,
				maxlength: 255
			}
		},
		messages: {
			pollname: {
				required: "This field is required",
				minlength: "Name must be at least 3 characters",
				maxlength: "Maximum limit is  255 characters"
			},
			question: {
				required: "This field is required",
				minlength: "Question must be at least 3 characters",
				maxlength: "Maximum limit is  255 characters"
			},
			answer: {
				required: "This field is required",
				minlength: "Answer must be at least 3 characters",
				maxlength: "Maximum limit is  255 characters"
			}
		}
	})
})