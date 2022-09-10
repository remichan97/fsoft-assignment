$().ready(function () {
	$("#edit-profile").validate(
		{
			rules: {
				fName: {
					required: true,
					minlength: 3,
					maxlength: 30
				},
				lName: {
					required: true,
					minlength: 3,
					maxlength: 30
				},
				phone: {
					required: true,
					number: true,
					minlength: 9,
					maxlength: 13
				},
				desc: {
					maxlength: 200
				},
			},
			messages: {
				fName: {
					required: "This field is required!",
					minlength: "First Name must have at least 3 characters!",
					maxlength: "Maximum limit is 200 characters"
				},
				lName: {
					required: "This field is required!",
					minlength: "Last name must have at least 3 characters!",
					maxlength: "Maximum limit is 30 characters"
				},
				phone: {
					required: "This field is required!",
					number: "Input is not a valid phone number",
					minlength: "Content must have at least 9 characters!",
					maxlength: "Maximum limit is 13 characters"
				},
				desc: {
					maxlength: "Maximum limit is 200 chatacters"
				}
			}
		}
	)
})