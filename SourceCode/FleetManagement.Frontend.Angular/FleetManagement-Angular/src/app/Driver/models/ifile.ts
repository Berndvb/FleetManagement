import { Byte } from "@angular/compiler/src/util";

export interface IFile {
    fileId: number;
    fileType: string;
    fileName: string;
    contentType: string;
    content: Byte[];
}
