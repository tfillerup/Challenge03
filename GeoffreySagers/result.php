<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>AlphaNumeric String Parsing</title>
<link href="css/styles.css" rel="stylesheet" type="text/css">
<?php include('functions.php'); ?>
</head>
<body>
	<div class="results">
		<?php
			$stringtoparse = $_POST['stringtoparse'];
			echo(parseString($stringtoparse));
		?>
	</div>
	<div class="button"><a href="index.php">Parse another string &raquo;</a></div>
</body>
</html>