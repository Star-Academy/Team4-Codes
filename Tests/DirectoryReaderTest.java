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

public class DirectoryReaderTest {
    public InvertedIndex invertedIndex = new InvertedIndex();
    public DirectoryReader directoryReader = new DirectoryReader(invertedIndex);
    File rootDirectory;
    File file;
    File file2;
    File file3;
    @Rule
    public TemporaryFolder folder = new TemporaryFolder();

    @Before
    public void createFile() throws IOException {
        rootDirectory = folder.newFolder("root");
        file = new File(rootDirectory, "file1.txt");
        file2 = new File(rootDirectory, "file2.txt");
        file3 = new File(rootDirectory, "file3.txt");

        if (!file2.exists()) {
            file2.createNewFile();
        }
        if (!file.exists()) {
            file.createNewFile();
        }
        FileWriter fileWriter = new FileWriter(file);
        FileWriter fileWriter2 = new FileWriter(file2);
        fileWriter.write("hello danial saba");
        fileWriter2.write("hello abbas");
        fileWriter.close();
        fileWriter2.close();
        file3.delete();
    }

    @Test
    public void readFileTest() {
        String result = directoryReader.readFile(file);
        String expected = "hello danial saba ";
        assertEquals(expected, result);

        result = directoryReader.readFile(file3);
        expected = "";
        assertEquals(expected, result);
    }

    @Test
    public void readFileList(){
        directoryReader = new DirectoryReader(rootDirectory, invertedIndex);
        directoryReader.goInFolder();
        assertEquals(new HashMap<>(){{
            put("hello", new HashSet<>(){{
                add("file1.txt");
                add("file2.txt");
            }});
            put("saba", new HashSet<>(){{
                add("file1.txt");
            }});
            put("danial", new HashSet<>(){{
                add("file1.txt");
            }});
            put("abbas", new HashSet<>(){{
                add("file2.txt");
            }});
        }},invertedIndex.getTokens());
    }

    @Test
    public void testForConstructors(){
        DirectoryReader directoryReader1 = new DirectoryReader("file.txt", invertedIndex);
    }



}
