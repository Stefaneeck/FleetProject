"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.checkDriverUniqueValidator = void 0;
function checkDriverUniqueValidator(val, driverService) {
    return function (control) {
        var v = +control.value;
        if (isNaN(v)) {
            return { 'gte': true, 'requiredValue': val };
        }
        if (v <= +val) {
            return { 'gte': true, 'requiredValue': val };
        }
        return null;
    };
}
exports.checkDriverUniqueValidator = checkDriverUniqueValidator;
//# sourceMappingURL=unique.driver.validator.js.map