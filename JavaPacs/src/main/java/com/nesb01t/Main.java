package com.nesb01t;

import com.nesb01t.api.DcmResultGenerator;
import com.nesb01t.com.DcmInfo;
import com.nesb01t.utils.FileReadUtils;
import com.nesb01t.utils.FileWriteUtils;

import java.io.File;
import java.util.List;

public class Main {
    public static void main(String[] args) throws Exception {
        /*
          功能开发情景
         */
        DcmInfo info = new DcmInfo("E:\\JavaPaces\\dicom\\1.dcm"); // 生成 DcmInfo
        FileWriteUtils.writeAllAttrs("E:\\JavaPaces\\dicom\\2.txt", info); // 读取所有 Attrs 并输出到文本
        String result = DcmResultGenerator.generateDicomResult(info); // 生成 Dcm 串并输出到控制台
        System.out.println(result);

        /*
          功能使用情景
         */
        List<File> dcmFileList = FileReadUtils.getDcmFileList("E:\\JavaPaces\\dicom");
        for (File f : dcmFileList) {
            DcmInfo di = new DcmInfo(f.getPath());
            String res = DcmResultGenerator.generateDicomResult(di);
            System.out.println("[DEBUG] " + f.getPath() + " 文件的内容串为 " + res);
        }
    }
}