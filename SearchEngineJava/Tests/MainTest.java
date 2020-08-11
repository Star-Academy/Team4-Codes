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


public class MainTest {
    @Test
    public void testMain(){
        System.out.println("test MAIN");
    }


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

}




