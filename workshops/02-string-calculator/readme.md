# String Calculator Kata

Credit: <a href="https://osherove.com/tdd-kata-1">Roy Osherove</a>

#### Before you begin

- Solve each set of requirements in order, as you would do for a business case
- Do not look ahead to future requirements. Business requirements expand as the customer requires them: we can't (and shouldn't) plan ahead for every possible scenario
- Do not solve for cases outside of the scope of the requirements. Exceptions are fine when inputs are not catered for within the specification

<details>
    <summary>Spec #1</summary>
    <p>
    Create a simple String calculator with a method signature:
    <pre><code>int Add(string numbers)</code></pre>
    The method can take up to two numbers, separated by commas, and will
    return their sum. For example "" or "1" or "1,2" as inputs. For an
    empty string it will return 0.
    </p>
    <p>
      <h5>Hints</h5>
      <ul>
        <li>Start with the simplest test case of an empty string and move to one and two numbers</li>
        <li>Remember to solve things as simply as possible so that you force yourself to write tests you did not think about</li>
        <li>Remember to refactor after each passing test</li>
      </ul>
    </p>
</details>
<details>
  <summary>Spec #2</summary>
  <p>
  Allow the Add method to handle an unknown amount of numbers
  </p>
</details>
<details>
  <summary>Spec #3</summary>
  <p>
    Allow the Add method to handle new lines between numbers (instead of commas).
    <ol data-rte-list="default">
      <li>
        The following input is ok: "1\n2,3" (will equal 6)
      </li>
      <li>
        The following input is NOT ok: "1,\n" (not need to prove it - just clarifying). Invalid input may produce unspecified errors.
      </li>
    </ol>
  </p>
</details>
<details>
  <summary>Spec #4</summary>
  Support different delimiters

To change a delimiter, the beginning of the string will contain a separate line that looks like
this: "//[delimiter]\n[numbers]" for example "//;\n1;2" should return three where the default
delimiter is ";".

The first line is optional. All existing scenarios should still be supported

</ol>
</details>

<details>
  <summary>Spec #5</summary>
    Calling `Add` with a negative number will throw an exception:
    "negatives not allowed" - and the negative that was passed.

    If there are multiple negatives, show all of them in the exception message.

    STOP HERE if you are a beginner. Continue if you can finish the steps so far in less than 30
    minutes.

</details>
<details>
  <summary>Spec #6</summary>
    Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2
</details>
<details>
  <summary>Spec #6</summary>
     Delimiters can be of any length with the following format: "//[delimiter]\n",
     for example: "//[***]\n1***2***3" should return 6

</details>
<details>
  <summary>Spec #7</summary>
  Allow multiple delimiters like this:

  "//[delim1][delim2]\n"
  for example
  "//[*][%]\n1*2%3" should return 6

  - make sure you can also handle multiple delimiters with length longer than one char
</details>
