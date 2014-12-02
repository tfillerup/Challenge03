#!/usr/bin/env scala

/**
 * STG Code Challenge 3
 *
 * @author Ray Hunter ray.hunter@stgconsulting.com
 * @since 2014-12-01
 */
object CountNumbers {

  /**
   *
   * @param args
   */
  def main(args: Array[String]) {
		println("STG Code Challenge 3 : Ray Hunter\n")
		
    for (line <- io.Source.stdin.getLines()) {
      process(line)
    }
  }

  /**
   *
   * @param input
   */
  def process(input: String) {

    // regex pattern to find numbers
    val numberPattern = "[+-]?\\d+".r

    // find letters (lower and upper case)
    val charPattern = "[a-zA-Z]".r

    // regex to fidn them all in the input
    val numbers = numberPattern findAllIn input
    val characters = charPattern findAllIn input

    // convert the numbers to integers and sum them up
    val sum = numbers.map(_.toInt).sum

    // determine the tolal
    val totalChars = characters.size

    // handle the math
    val output = math.round(sum.toDouble / totalChars.toDouble)

    println("Input: " + input)
    println("Output: " + output + "\t[" + sum + " / " + totalChars + " = " + output + "]")
    println()
  }

}

// process the input
CountNumbers.main(args);
