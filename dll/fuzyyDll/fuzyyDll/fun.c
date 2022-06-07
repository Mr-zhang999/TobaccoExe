#include  "fis.h"
_declspec(dllexport) double cacFuzzy(double d1, double d2);
//#include<iostream>
//using namespace std;
//#include <stdio.h>
double cacFuzzy(double d1, double d2)
//double main()

{
	FIS* fis;
	int i, j;
	int debug = 1;

	double** dataMatrix, ** fisMatrix, ** outputMatrix;
	char* fis_file, *data_file;
	int data_row_n, data_col_n, fis_row_n, fis_col_n;

	//  data_file = "dataMatrixFile.txt";
	fis_file = "fisMatrixFile.txt";

	/* ���ļ������������ݾ����ģ�����󣬽�������ά������*/
	fisMatrix = returnFismatrix(fis_file, &fis_row_n, &fis_col_n);

	//����������Ž���ά����,
	//data_row_n Ϊ���������������һ�����ݣ���ͬʱ���������������޸�
	//data_col_n  Ϊ����������������������仯�����޸�
	data_row_n = 1;
	data_col_n = 2;
	dataMatrix = (DOUBLE**)fisCreateMatrix(data_row_n, data_col_n, sizeof(DOUBLE));
	dataMatrix[0][0] = 1;
	dataMatrix[0][1] = 2;
	//dataMatrix[0][2] = 3;


	/* build FIS data structure ����ģ�����ݽṹ*/
	fis = (FIS*)fisCalloc(1, sizeof(FIS));
	/*��fisMatrix�е����ݵ��뵽fis��*/
	fisBuildFisNode(fis, fisMatrix, fis_col_n, MF_POINT_N);

	/* error checking ������*/
	if (data_col_n < fis->in_n) {
		printf("Given FIS is a %d-input %d-output system.\n",
			fis->in_n, fis->out_n);
		printf("Given data file does not have enough input entries.\n");
		fisFreeMatrix((void**)dataMatrix, data_row_n);
		fisFreeMatrix((void**)fisMatrix, fis_row_n);
		fisFreeFisNode(fis);
		fisError("Exiting ...");
	}
	/* fisDebugging �����������*/
	if (debug)
		fisPrintData(fis);

	/* create output matrix �����������5x1*/
	outputMatrix = (double**)fisCreateMatrix(data_row_n, fis->out_n, sizeof(double));

	/* evaluate FIS on each input vector ��ȡ����->��ʼģ������->�������*/
	for (i = 0; i < data_row_n; i++)
		getFisOutput(dataMatrix[i], fis, outputMatrix[i]);

	/* print output vector �õ��������ӡ*/
	for (i = 0; i < data_row_n; i++) {
		for (j = 0; j < fis->out_n; j++) {
			double res = outputMatrix[i][j];
			return res;
		}
		//  printf("%.12f ", outputMatrix[i][j]);
		// printf("\n");
	}

	///* clean up memory �����ڴ�*/
	//fisFreeFisNode(fis);
	//fisFreeMatrix((void**)dataMatrix, data_row_n);
	//fisFreeMatrix((void**)fisMatrix, fis_row_n);
	//fisFreeMatrix((void**)outputMatrix, data_row_n);
	//getchar();
	//return  0;
}
