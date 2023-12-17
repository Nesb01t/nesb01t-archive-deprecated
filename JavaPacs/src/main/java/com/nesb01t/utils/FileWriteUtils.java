package com.nesb01t.utils;

import com.nesb01t.com.DcmInfo;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.PrintStream;

public class FileWriteUtils {

    /**
     * 在指定路径写入 DcmInfo 的全部 Attrs
     * @param filePath
     * @param info
     * @throws FileNotFoundException
     */
    public static void writeAllAttrs(String filePath, DcmInfo info) throws FileNotFoundException {
        FileOutputStream fos = new FileOutputStream(filePath);
        PrintStream ps = new PrintStream(fos);
        ps.print(info.getAttributes());
    }

    /**
     * 在指定路径写入 DcmInfo 的结果字符串 Result
     * @param filePath
     * @param info
     * @throws Exception
     */
    public static void writeDcmResult(String filePath, DcmInfo info) throws Exception {
        FileOutputStream fos = new FileOutputStream(filePath);
        PrintStream ps = new PrintStream(fos);
        ps.print(info.getDcmResult());
    }
}
