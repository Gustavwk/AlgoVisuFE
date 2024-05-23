/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CompleteBudgetGetResponseDto } from '../models/CompleteBudgetGetResponseDto';
import type { NaivBudgetGetResponseDto } from '../models/NaivBudgetGetResponseDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class BudgetCalculatorService {
    /**
     * @param remainingCapital
     * @returns NaivBudgetGetResponseDto OK
     * @throws ApiError
     */
    public static getNaivBudget(
        remainingCapital?: number,
    ): CancelablePromise<NaivBudgetGetResponseDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/BudgetCalculator/NaivBudget',
            query: {
                'RemainingCapital': remainingCapital,
            },
        });
    }
    /**
     * @param remainingCapital
     * @param minimumPossibleSpending
     * @returns CompleteBudgetGetResponseDto OK
     * @throws ApiError
     */
    public static getCompleteBudget(
        remainingCapital?: number,
        minimumPossibleSpending?: number,
    ): CancelablePromise<CompleteBudgetGetResponseDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/BudgetCalculator/CompleteBudget',
            query: {
                'RemainingCapital': remainingCapital,
                'MinimumPossibleSpending': minimumPossibleSpending,
            },
        });
    }
}
