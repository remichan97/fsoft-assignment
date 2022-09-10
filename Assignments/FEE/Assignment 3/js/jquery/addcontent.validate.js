$().ready(function () {
	$("#add-content").validate(
		{
			rules: {
				contentname: {
					required: true,
					minlength: 10,
					maxlength: 200
				},
				brief: {
					required: true,
					minlength: 30,
					maxlength: 150
				},
				content: {
					required: true,
					minlength: 50,
					maxlength: 1000
				}
			},
			messages: {
				contentname: {
					required: "This field is required!",
					minlength: "Name must have at least 10 characters!",
					maxlength: "Maximum limit is 200 characters"
				},
				brief: {
					required: "This field is required!",
					minlength: "Briefing must have at least 30 characters!",
					maxlength: "Maximum limit is 150 characters"
				},
				content: {
					required: "This field is required!",
					minlength: "Content must have at least 50 characters!",
					maxlength: "Maximum limit is 1000 characters"
				},
			}
		}
	)
})