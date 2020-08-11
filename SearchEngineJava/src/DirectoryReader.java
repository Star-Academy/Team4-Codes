import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class DirectoryReader {
    final static String DATA_SET_PATH = "EnglishData";
    InvertedIndex invertedIndex;
    File directory;
    File[] directoryListing;

    public DirectoryReader(String path, InvertedIndex invertedIndex){
        directory = new File(path);
        directoryListing = directory.listFiles();
        this.invertedIndex = invertedIndex;
    }

    public DirectoryReader(InvertedIndex invertedIndex){
        directory = new File(DATA_SET_PATH);
        directoryListing = directory.listFiles();
        this.invertedIndex = invertedIndex;
    }

    public DirectoryReader(File directory, InvertedIndex invertedIndex){
        this.directory = directory;
        this.invertedIndex = invertedIndex;
        directoryListing = this.directory.listFiles();
    }

    public void goInFolder(){
        if (directoryListing != null) { //empty directory handling
            for (File child : directoryListing) {
                if (child.length() != 0) { //empty file handling
                    //read the files put all of their words in the list
                    String result = readFile(child);
                    invertedIndex.updateMap(result, child.getName());
                }
            }
        }
    }

    String readFile(File file){
        String string = "";
        try {
            Scanner fileScanner = new Scanner(file);
            while (fileScanner.hasNext()) {
                String line = fileScanner.next();
                line = line.toLowerCase();
                string += line + " ";
            }
            fileScanner.close();
        } catch (FileNotFoundException e) {
            System.out.println("file not found");
        }
        return string;
    }
}
