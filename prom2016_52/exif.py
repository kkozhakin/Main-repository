import exifread

# Open image file for reading (binary mode)
path_name = "exif_examples/sample.jpg"
f = open(path_name, 'rb')

# Return Exif tags
tags = exifread.process_file(f)

for k in tags.keys():
    if k not in ('JPEGThumbnail', 'TIFFThumbnail', 'Filename', 'EXIF MakerNote') and (
                k.startswith('ISO') or k.startswith('EXIF ISO')):
        print "Key: '{:40}',; value '{:20}' ".format(k, tags[k])
        s = tags[k].printable.strip()
        print s

f.close()
