package com.nesb01t.api;

import org.dcm4che3.data.Attributes;
import org.dcm4che3.io.DicomInputStream;

import java.io.File;
import java.io.IOException;

public class FileParser {
    /**
     * 从指定路径文件中得到 Attrs
     * @param filePath
     * @return Attributes
     * @throws IOException
     */
    public static Attributes getAttrsFromFile(String filePath) throws IOException {
        File file = new File(filePath);
        DicomInputStream dis = new DicomInputStream(file);
        return dis.readDataset();
    }
}
