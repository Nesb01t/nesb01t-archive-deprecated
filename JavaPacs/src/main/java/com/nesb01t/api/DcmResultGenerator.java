package com.nesb01t.api;

import com.nesb01t.com.DcmInfo;

public class DcmResultGenerator {
    private static final String INTER_CODE = "*";
    public static String generateDicomResult(DcmInfo dcmInfo) throws Exception {
        // 接收合法的源字符串
        String instanceUID = dcmInfo.getInstanceUID();
        String manufacturer = dcmInfo.getManufacturer();
        String stationName = dcmInfo.getStationName();
        if (validateInterCode(instanceUID)) {
            throw new Exception("meet instanceUID validated error!");
        }
        if (validateInterCode(manufacturer)) {
            throw new Exception("meet manufacturer validated error!");
        }
        if (validateInterCode(stationName)) {
            throw new Exception("meet stationName validated error!");
        }

        // 生成结果字符串
        StringBuilder result = new StringBuilder(10);
        result.append(manufacturer);
        result.append(INTER_CODE);
        result.append(stationName);
        result.append(INTER_CODE);
        result.append(instanceUID);

        return result.toString();
    }

    private static boolean validateInterCode(String str) {
        return str.contains(INTER_CODE);
    }
}
