# String Calculator Kata

Credit: <a href="https://osherove.com/tdd-kata-1">Roy Osherove</a>

#### Before you begin
- Solve each set of requirements in order, as you would do for a business case
- Do not look ahead to future requirements. Business requirements expand as the customer requires them: we can't (and shouldn't) plan ahead for every possible scenario
- Do not solve for cases outside of the scope of the requirements. Exceptions are fine when inputs are not catered for within the specification


<details>
    <summary>Reveal</summary>
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

  <li>
    <details>
      <summary>Reveal</summary>
      <p>
      Allow the Add method to handle an unknown amount of numbers
      </p>
    </details>
  </li>
  <li>
    <details>
      <summary>Reveal</summary>
      <p>
        Allow the Add method to handle new lines between numbers (instead of commas).
        <ol data-rte-list="default">
          <li>
            The following input is ok: ΓÇ£1\n2,3ΓÇ¥ (will equal 6)
          </li>
          <li>
            The following input is NOT ok: ΓÇ£1,\nΓÇ¥ (not need to prove it - just clarifying). Invalid input may produce unspecified errors.
          </li>
        </ol>
      </p>
    </details>
  </li>
  <li>
    <details>
      <summary>Reveal</summary>
    <pre><code>Support different delimiters</code></pre>
    <ol data-rte-list="default">
      <li>
        <pre><code>to change a delimiter, the beginning of the string will contain a separate line that looks like this: ΓÇ£//[delimiter]\n[numbersΓÇª]ΓÇ¥ for example ΓÇ£//;\n1;2ΓÇ¥ should return three where the default delimiter is ΓÇÿ;ΓÇÖ .</code></pre>
      </li>
      <li>
        <pre><code>the first line is optional. all existing scenarios should still be supported</code></pre>
        <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
      </li>
    </ol>
    </details>
  </li>
  <li>
    <pre><code>Calling Add with a negative number will throw an exception ΓÇ£negatives not allowedΓÇ¥ - and the negative that was passed. </code></pre>
    <pre><code>if there are multiple negatives, show all of them in the exception message.</code></pre>
    <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
    <pre><code>STOP HERE if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes.</code></pre>
    <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
  </li>
  <li>
    <pre><code>Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2</code></pre>
    <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
  </li>
  <li>
    <pre><code>Delimiters can be of any length with the following format: ΓÇ£//[delimiter]\nΓÇ¥ for example: ΓÇ£//[***]\n1***2***3ΓÇ¥ should return 6</code></pre>
    <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
  </li>
  <li>
    <pre><code>Allow multiple delimiters like this: ΓÇ£//[delim1][delim2]\nΓÇ¥ for example ΓÇ£//[*][%]\n1*2%3ΓÇ¥ should return 6.</code></pre>
    <pre><code>ΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇöΓÇö</code></pre>
  </li>
  <li>
    <pre><code>make sure you can also handle multiple delimiters with length longer than one char</code></pre>
  </li>
</ol>
