<?php
function sumArray($arrayinput){
	$sum=0;
	for($x=0;$x<count($arrayinput);$x++){
		$sum+=$arrayinput[$x];
		}
	return($sum);
	}
	
function displayArray($arrayinput,$arraytitle){
	echo("<h4>".$arraytitle. " (" . count($arrayinput) . ")</h4>");
	for($y=0;$y<count($arrayinput);$y++){
		echo($arrayinput[$y].", ");
		}
	}	

function parseString($stringtoparse){
	$cleanstring = preg_replace("/[^A-Za-z0-9\-\s]/", "", $stringtoparse);
	$numbers=preg_replace("/[^0-9\-\s]/", " ", $cleanstring);
	$numarray=explode(" ",$numbers);
	$numarray=array_values(array_filter($numarray));
	$letters=preg_replace("/[^A-Za-z]/", "", $cleanstring);
	$letterarray=str_split($letters);
	$lettercount=count($letterarray);
	$sum = sumArray($numarray);
	displayArray($letterarray,"Letters");
	displayArray($numarray,"Numbers");
	echo("<p>" . $sum . " &divide; " . $lettercount . " = " . $sum/$lettercount . "</p>");
	echo("<p><b>Integer Value: " . round($sum/$lettercount,0) . "</b></p>");
}
?>