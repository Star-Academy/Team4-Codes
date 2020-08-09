import org.junit.Rule;
import org.junit.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.Spy;
import org.mockito.junit.MockitoJUnit;
import org.mockito.junit.MockitoRule;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

import static org.junit.Assert.*;
/*

public class MainTest {

    @Rule
    public MockitoRule mockitoRule = MockitoJUnit.rule();

    public Main main = new Main();

    @Test
    public void outputTest() {
        Set<String> set = new HashSet<>() {{
            add("12");
            add("18");
        }};
        assertEquals(main.output(set), "12 18 ");
    }

    @Test
    public void outputTest2() {
        Set<String> set = new HashSet<>();
        assertEquals(main.output(set), "no result found");
    }

    @Spy InvertedIndex invertedIndex = new InvertedIndex();


    @Test
    public void activityStart() {
        invertedIndex.getTokens().put("hello", new HashSet<>() {{
            add("5922");
            add("6289");
        }});
        invertedIndex.getTokens().put("girl", new HashSet<>(){{
            add("7231");
            add("5922");
        }});

        main.allTokens = invertedIndex;

        UserInputProcessor userInputProcessor = Mockito.mock(UserInputProcessor.class);
        Mockito.when(userInputProcessor.inputFromUser()).thenReturn(new String[]{"hello", "-girl"});
        main.activityContent();
        assertSame(main.output(main.output), "6289 ");
    }
}


 */