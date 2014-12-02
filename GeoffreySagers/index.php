<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>AlphaNumeric String Parsing</title>
<link href="css/styles.css" rel="stylesheet" type="text/css">
</head>
<body>
<div class="input">
	<h3>Change Finder</h3>
	<p>This form will search for all the numbers in a string, add them together, then return that final number divided by the total amount of letters in the string.</p>
	<form method="post" action="result.php">
			<label>Enter String to Parse</label><br>
			<textarea name="stringtoparse" id="stringtoparse"></textarea><br>
			<input type="submit" name="Submit" value="Submit"/>
	</form>
</div>
</body>
</html>