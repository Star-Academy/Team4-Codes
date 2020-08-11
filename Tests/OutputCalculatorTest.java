import org.junit.Before;
import org.junit.Test;
import org.junit.runner.JUnitCore;
import org.junit.runners.JUnit4;

import java.util.HashSet;
import java.util.Set;

import static org.junit.Assert.*;


public class OutputCalculatorTest {
    public OutputCalculator outputCalculator;
    @Before
    public void implementArrays() {
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> s1 = new HashSet<>() {{
            add("12");
            add("15");
        }};

        Set<String> s2 = new HashSet<>() {{
            add("15");
            add("20");
        }};

        Set<String> s3 = new HashSet<>() {{
            add("12");
            add("15");
            add("40");
        }};

        Set<String> s4 = new HashSet<>() {{
            add("40");
        }};

        invertedIndex.getTokens().put("hello", s1);
        invertedIndex.getTokens().put("friend", s2);
        invertedIndex.getTokens().put("boos", s3);
        invertedIndex.getTokens().put("soap", s4);
        outputCalculator = new OutputCalculator(invertedIndex);
    }
    @Test
    public void returnOutput() {
        String[] words = {"hello", "-friend", "+boos", "soap"};
        Set<String> returnedOut = outputCalculator.returnOutput(words);
        Set<String> expectedOut = new HashSet<>() {{
            add("40");
            add("12");
        }};
        assertEquals(expectedOut, returnedOut);
    }
}
