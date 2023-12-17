package com.nesb01t.utils;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class FileReadUtils {
    public static List<File> getDcmFileList(String folderPath) {
        File file = new File(folderPath);
        File[] fileList = file.listFiles();

        List<File> dcmFileList = new ArrayList<>();
        for (File f : fileList) {
            if (!f.isDirectory()) {
                String fileName = f.getName();
                String fileSuffix = fileName.substring(fileName.lastIndexOf('.') + 1);
                if (fileSuffix.equals("dcm")) {
                    dcmFileList.add(f);
                }
            }
        }

        return dcmFileList;
    }
}
