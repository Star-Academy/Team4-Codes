import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.TemporaryFolder;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.HashSet;

import static org.junit.Assert.*;

public class InvertedIndexTest {

    InvertedIndex invertedIndex;

    @Test
    public void testUpdateMap() {
        invertedIndex = new InvertedIndex();
        invertedIndex.updateMap("hello friend how are", "1256");
        invertedIndex.updateMap("hello button are", "789");
        assertEquals(new HashMap<>() {{
            put("hello", new HashSet<>() {{
                add("1256");
                add("789");
            }});
            put("friend", new HashSet<>(){{
                add("1256");
            }});
            put("how", new HashSet<>(){{
                add("1256");
            }});
            put("are", new HashSet<>(){{
                add("1256");
                add("789");
            }});
            put("button", new HashSet<>(){{
                add("789");
            }});
        }}, invertedIndex.getTokens());
    }
}