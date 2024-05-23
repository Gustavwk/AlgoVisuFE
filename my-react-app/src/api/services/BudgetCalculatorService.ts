/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CompleteBudgetDto } from '../models/CompleteBudgetDto';
import type { NaivBudgetDto } from '../models/NaivBudgetDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class BudgetCalculatorService {
    /**
     * @param remainingCapital
     * @returns NaivBudgetDto OK
     * @throws ApiError
     */
    public static getNaivBudget(
        remainingCapital?: number,
    ): CancelablePromise<NaivBudgetDto> {
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
     * @returns CompleteBudgetDto OK
     * @throws ApiError
     */
    public static getCompleteBudget(
        remainingCapital?: number,
        minimumPossibleSpending?: number,
    ): CancelablePromise<CompleteBudgetDto> {
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
