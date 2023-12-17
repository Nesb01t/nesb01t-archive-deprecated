package com.nesb01t.com;

import com.nesb01t.api.DcmResultGenerator;
import com.nesb01t.api.FileParser;
import com.nesb01t.utils.FileWriteUtils;
import org.dcm4che3.data.Attributes;
import org.dcm4che3.data.Tag;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

public class DcmInfo {
    private Attributes attributes;
    private final String stationName;
    private final String manufacturer;
    private final String instanceUID;

    public DcmInfo(String filePath) throws IOException {
        attributes = FileParser.getAttrsFromFile(filePath);
        manufacturer = attributes.getString(Tag.Manufacturer);
        instanceUID = attributes.getString(Tag.SOPInstanceUID);
        stationName = attributes.getString(Tag.StationName);
    }

    public void writeAllAttrs(String filePath) throws FileNotFoundException {
        FileWriteUtils.writeAllAttrs(filePath, this);
    }

    public String getDcmResult() throws Exception {
        return DcmResultGenerator.generateDicomResult(this);
    }

    public Attributes getAttributes() {
        return attributes;
    }

    public String getManufacturer() {
        return manufacturer;
    }

    public String getInstanceUID() {
        return instanceUID;
    }

    public String getStationName() {
        return stationName;
    }

}
